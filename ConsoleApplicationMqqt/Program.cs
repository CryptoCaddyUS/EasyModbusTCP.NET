﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplicationMqqt
{
    class Program
    {
        static void Main(string[] args)
        {
            EasyModbus.EasyModbus2Mqtt easyModbus2Mqtt= new EasyModbus.EasyModbus2Mqtt();
            easyModbus2Mqtt.AutomaticReconnect = false;
            easyModbus2Mqtt.MqttBrokerAddress = "broker.hivemq.com";
            easyModbus2Mqtt.IPAddress = "127.0.0.1";
            easyModbus2Mqtt.AddReadOrder(EasyModbus.FunctionCode.ReadCoils, 2, 0, 200, new string[] { "easymodbusclient/customtopic1", "easymodbusclient/customtopic2" });
//            easyModbus2Mqtt.AddReadOrder(EasyModbus.FunctionCode.ReadHoldingRegisters, 10, 0, 200);
            easyModbus2Mqtt.AddReadOrder(EasyModbus.FunctionCode.ReadInputRegisters, 10, 0, 200);
            EasyModbus.ReadOrder readOrder = new EasyModbus.ReadOrder();
            readOrder.Hysteresis = new int[10] { 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 };
            readOrder.Unit = new string[10] {"°C", "°C", "°C", "°C", "°C", "°C", "°C", "°C", "°C", "°C"};
            readOrder.Scale = new float[10] { 0.1f, 0.1f, 0.1f, 0.1f, 0.1f, 0.1f, 0.1f, 0.1f, 0.1f, 0.1f };
            readOrder.Quantity = 10;
            readOrder.StartingAddress = 10;
            readOrder.FunctionCode = EasyModbus.FunctionCode.ReadHoldingRegisters;
            
            easyModbus2Mqtt.AddReadOrder(readOrder);
            easyModbus2Mqtt.start();
        }
    }
}
