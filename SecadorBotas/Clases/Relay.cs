using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SecadorBotas.Clases
{
    class Relay
    {

        #region Variables_Instancias

       public String US = "admin";
       public String PW = "FishKen";
       public int PortNum = 23;
       TelnetConnection tc = null;//Instancia vacía TELNET

        #endregion Variables_Instancias


        #region MétodoObtenerIP

        public void ObtenerIP(String Name)
        {
            
                if (tc == null)
                {
                    tc = new TelnetConnection(Name);
                    string s = tc.Login(US, PW, 100);
                    String c = s.TrimEnd();
                    c = s.Substring(c.Length - 1, 1);

                    if (c != "$" && c != ">")
                    {
                        tc.TelnetClose();

                    }   
              }
        }

        #endregion MétodoObtenerIP


        #region MétodoEnvíoInstruccionesRelay

        public String EnvioInstruccionRelay(String C)
        {
            try
            {
                tc.WriteLine(C);

                System.Threading.Thread.Sleep(100);

                string s2 = tc.Read();
                if (s2 == null) s2 = "Problema de conexion rele!";
                return s2;
            }
            catch (Exception e)
            {
                return "" + e.Message;
            }
        }

        #endregion MétodoEnvíoInstruccionesRelay
    

        #region CerrarComunicacionRelay

        public void Close()
        {
            tc.TelnetClose();
            tc = null;
        }

        #endregion CerrarComunicacionRelay

       

    }
}
