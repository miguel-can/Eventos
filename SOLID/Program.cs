using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID
{
    public class Program
    {
        static void Main(string[] args)
        {

            ListaEventos lsrEventos = new ListaEventos();
            List<ListaEventos> lstEventosFinal = new List<ListaEventos>();
            DateTime dtHoy = DateTime.Now;

            LeerArchivo objLeerArchivo = new LeerArchivo();
            string[] arrContenido = null;
            arrContenido = objLeerArchivo.ObtenerArchivo(@"C:\SOLID\file.txt");
            
            List<ListaEventos> lstEventos = (from l in arrContenido
                                             select new ListaEventos
                                             {
                                                 cEvento = l.Split('|')[0],
                                                 dtEvento = Convert.ToDateTime(l.Split('|')[1]),
                                                 iTotalHOras = (dtHoy - Convert.ToDateTime(l.Split('|')[1])).TotalHours,
                                                 iTotalDias = (dtHoy - Convert.ToDateTime(l.Split('|')[1])).TotalDays,
                                                 iTotalMinutos = (dtHoy - Convert.ToDateTime(l.Split('|')[1])).TotalMinutes
                                             }).ToList();


            foreach (ListaEventos item in lstEventos )
            {
                //Meses
                if (item.iTotalDias >= 1 || item.iTotalDias <= -1)
                {

                    if (item.iTotalDias >= 1)
                    {
                        lstEventosFinal.Add(new ListaEventos()
                        {
                            cEvento = item.cEvento,
                            cEventoImprime = (item.iTotalDias > 0 && item.iTotalDias < 30 ? "Ocurrio hace " + Math.Truncate(item.iTotalDias).ToString() + " días" : "Ocurrio hace " + Math.Truncate(item.iTotalDias/30).ToString() + " mese(s)")
                        });
                    }
                    else
                    {
                        lstEventosFinal.Add(new ListaEventos()
                        {
                            cEvento = item.cEvento,
                            cEventoImprime = (Math.Abs(item.iTotalDias) > 0 && Math.Abs(item.iTotalDias) < 30 ? "Ocurrira dentro de  " + Math.Truncate(Math.Abs(item.iTotalDias)).ToString() + " días" : "Ocurrira dentro de  " + Math.Truncate(Math.Abs(item.iTotalDias/30)).ToString() + " mese(s)")
                        });
                    }
                }
                else if (item.iTotalHOras >= 1 || item.iTotalHOras <= -1)
                {
                    if (item.iTotalHOras >= 1)
                    {
                        lstEventosFinal.Add(new ListaEventos()
                        {
                            cEvento = item.cEvento,
                            cEventoImprime = "Ocurrio hace " + Math.Truncate(item.iTotalHOras).ToString() + " horas"
                        });
                    }
                    else
                    {
                        lstEventosFinal.Add(new ListaEventos()
                        {
                            cEvento = item.cEvento,
                            cEventoImprime = "Ocurrira dentro de " + Math.Truncate(Math.Abs(item.iTotalHOras)).ToString() + " horas"
                        });
                    }

                }
                else if (item.iTotalMinutos >= 1 || item.iTotalMinutos <= 1)
                {
                    if (item.iTotalMinutos >= 1)
                    {
                        lstEventosFinal.Add(new ListaEventos()
                        {
                            cEvento = item.cEvento,
                            cEventoImprime = "Ocurrio hace " + Math.Truncate(item.iTotalMinutos).ToString() + " minutos"
                        });
                    }
                    else
                    {
                        lstEventosFinal.Add(new ListaEventos()
                        {
                            cEvento = item.cEvento,
                            cEventoImprime = "Ocurrira dentro de " + Math.Truncate(Math.Abs(item.iTotalMinutos)).ToString() + " minutos"
                        });
                    }
                }             
            }


            foreach (ListaEventos item in lstEventosFinal)
            {
                Console.WriteLine(item.cEvento + " " + item.cEventoImprime);
            }


            Console.Write("Press any key to close the Calculator console app...");
            Console.ReadKey();

        }
    }
}
