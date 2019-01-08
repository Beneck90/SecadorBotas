using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SecadorBotas.Clases
{   
    enum Verbs
    {
        WILL = 251,
        WONT = 252,
        DO = 253,
        DONT = 254,
        IAC = 255
    }

    enum Options
    {
        SGA = 3
    }

    class Conex
    {
       
        
        TcpClient t;
        int TimeOutMs = 100;

        internal Conex(string name)

        {
            t = new TcpClient();
            t.Connect(name, 23);
        }      

        public Conex()
        {
            // TODO: Complete member initialization
        }

        internal void TelnetClose()
        {
            if (t != null) t.Close();
            t = null;
        }

       

        internal string Login(string Username, string Password, int LoginTimeOutMs)
        {
            
            int oldTimeOutMs = TimeOutMs;
            TimeOutMs = LoginTimeOutMs;
            string s = Read();
            if (!s.TrimEnd().EndsWith(":"))
                throw new Exception("Failed to connect : no login prompt");
            WriteLine(Username);

            s += Read();
            if (!s.TrimEnd().EndsWith(":"))
                throw new Exception("Failed to connect : no password prompt");
            WriteLine(Password);

            s += Read();
            TimeOutMs = oldTimeOutMs;
            return s;
        }

        internal void WriteLine(string cmd)
        {
            Write(cmd + "\n");
        }

        internal void Write(string cmd)
        {
            if (t == null) return;
            if (!t.Connected) return;
            byte[] buf = System.Text.ASCIIEncoding.ASCII.GetBytes(cmd.Replace("\0xFF", "\0xFF\0xFF"));
            t.GetStream().Write(buf, 0, buf.Length);
        }

        internal string Read()
        {
            if (t == null) return null;
            if (!t.Connected) return null;
            StringBuilder sb = new StringBuilder();
            do
            {
                ParseTelnet(sb);
                System.Threading.Thread.Sleep(TimeOutMs);
            } while (t.Available > 0);
            return sb.ToString();
        }

        internal bool IsConnected//Verifica si está conectdo el cable de red
        {
            get
            {
                if (t == null) return false;               
                return t.Connected;               
            }
        }

        void ParseTelnet(StringBuilder sb)
        {
            if (t == null) return;
            while (t.Available > 0)
            {
                int input = t.GetStream().ReadByte();
                switch (input)
                {
                    case -1:
                        break;
                    case (int)Verbs.IAC:
                        int inputverb = t.GetStream().ReadByte();
                        if (inputverb == -1) break;
                        switch (inputverb)
                        {
                            case (int)Verbs.IAC:
                                sb.Append(inputverb);
                                break;
                            case (int)Verbs.DO:
                            case (int)Verbs.DONT:
                            case (int)Verbs.WILL:
                            case (int)Verbs.WONT:
                                int inputoption = t.GetStream().ReadByte();
                                if (inputoption == -1) break;
                                t.GetStream().WriteByte((byte)Verbs.IAC);
                                if (inputoption == (int)Options.SGA)
                                    t.GetStream().WriteByte(inputverb == (int)Verbs.DO ? (byte)Verbs.WILL : (byte)Verbs.DO);
                                else
                                    t.GetStream().WriteByte(inputverb == (int)Verbs.DO ? (byte)Verbs.WONT : (byte)Verbs.DONT);
                                t.GetStream().WriteByte((byte)inputoption);
                                break;
                            default:
                                break;
                        }
                        break;
                    default:
                        sb.Append((char)input);
                        break;
                }
            }
        }

    }
  }

