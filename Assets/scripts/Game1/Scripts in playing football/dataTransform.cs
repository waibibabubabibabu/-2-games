using System;
using System.IO.Ports;
using System.Reflection;
using System.Text;
using System.Threading;
using UnityEngine;

public class dataTransform : MonoBehaviour
{
    public SerialPort sp;
    public int attention;
    public int count = 0;
    //使用API扫描：
    public string[] ScanPorts_API()
    {
        string[] portList = SerialPort.GetPortNames();
        return portList;
    }
    /// <summary>
    /// 打开串口
    /// </summary>
    /// <param name="_portName">端口号</param>
    /// <param name="_baudRate">波特率</param>
    /// <param name="_parity">校验位</param>
    /// <param name="dataBits">数据位</param>
    /// <param name="_stopbits">停止位</param>
    public void OpenSerialPort(string _portName, int _baudRate, Parity _parity, int dataBits, StopBits _stopbits)
    {
        try
        {
            if (sp==null||!sp.IsOpen)
            {
                sp = new SerialPort(_portName, _baudRate, _parity, dataBits, _stopbits);//绑定端口
                sp.Open();
                //使用线程接收数据
                Thread thread = new Thread(new ThreadStart(DataReceived));
                thread.Start();
            }
        }
        catch (Exception e)
        {
            //Debug.Log("出现异常");
            sp = new SerialPort();
            Debug.Log(e);
        }
    }

    /// <summary>
    /// 关闭串口
    /// </summary>
    public void CloseSerialPort()
    {
        sp.Close();
    }

    public void DataReceived()
    {
        while (true)
        {
            if (sp.IsOpen)
            {
                int count = sp.BytesToRead;
                if (count > 0)
                {
                    byte[] readBuffer = new byte[count];
                    //byte[] data = new byte[count];
                    try
                    {
                        sp.Read(readBuffer, 0, count);
                        //Debug.Log(readBuffer);
                        //Debug.Log(count);
                        /*if (count==51)    //是否符合接收长度
                        {
                            int index = 0;

                            for (int i = 0; i < count; i++)
                            {
                                if (index >= count) index = count - 1;		 //理论上不应该会进入此判断，但是由于传输的误码，导致数据的丢失，使得标志位与数据个数出错
                                data[index] = readBuffer[i];         //将数据存入数据处理数组data中
                                index++;
                            }
                        }*/
                      
                        DataProcessing(readBuffer);//数据处理
                    }
                    catch (Exception ex)
                    {
                        Debug.Log(ex.Message);
                    }
                }
            }
            Thread.Sleep(10);
        }
    }

    /// <summary>
    /// 数据处理
    /// </summary>
    /// <param name="data">字节数组</param>
    public void DataProcessing(byte[] data)
    {
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < data.Length; i++)
        {
            sb.AppendFormat("{0:x2}" + "", data[i]);
        }
        Debug.Log(sb.ToString());
        int index = 0;
        int eCount = 0;
        while(eCount<4)
        {
            if (sb[index] == 'e') eCount++;
            index++;
        }
        string targetstring = sb.ToString().Substring(index+1, 3);
        Debug.Log(targetstring);
        //计算attention

        int tmpattention = (targetstring[0]-'0') * 16 + targetstring[2]-'0';
        Debug.Log("得到的临时attention是："+tmpattention);
        if (tmpattention > 0 && tmpattention <= 100)
        {
            attention = (attention * count + tmpattention) / (count + 1);
            count++;
        }
        else Debug.Log("attention越界！");
    }
    
}
/*
-----------------------------------
©著作权归作者所有：来自51CTO博客作者恬静的小魔龙的原创作品，请联系作者获取转载授权，否则将追究法律责任
【Unity3D软硬件】Unity3D与串口通信 SerialPort类完全教程
https://blog.51cto.com/u_15296123/5256339
*/
/*
————————————————
版权声明：本文为CSDN博主「辰似五味」的原创文章，遵循CC 4.0 BY - SA版权协议，转载请附上原文出处链接及本声明。
原文链接：https://blog.csdn.net/qq_44879321/article/details/120970841
*/