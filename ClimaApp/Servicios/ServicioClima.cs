using System;
using System.Threading.Tasks;
using System.Net.Http;
using ClimaApp.Clases;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ClimaApp.Servicios{
    public class ServicioClima{
        static string Key = "xxxxxxxxxxx1234567890"; //Agregar su APPID 

        public static async Task<ClimaApp.Clases.Clima> ConsultarClima(string pCiudad) {
            var conexion = $"https://api.openweathermap.org/data/2.5/weather?q={pCiudad}&appid={Key}";

            //Abrir una conexion a Web services usando el HTTPClient
            using (var cliente = new HttpClient()) {
                var peticion = await cliente.GetAsync(conexion);
                if (peticion != null) {
                    var json = peticion.Content.ReadAsStringAsync().Result;
                    var datos = (JContainer)JsonConvert.DeserializeObject(json);

                    if (datos["weather"] != null) {
                        var mClima = new ClimaApp.Clases.Clima();
                        mClima.Pais = (string)datos["country"];
                        mClima.Ciudad = (string)datos["name"];
                        mClima.Titulo = mClima.Pais + " - " + mClima.Ciudad;
                        mClima.Temperatura = ((float)datos["main"]["temp"] - 273.15).ToString("N2") + " °C";
                        mClima.Viento = (string)datos["wind"]["speed"] + " mph";
                        mClima.Humedad = (string)datos["main"]["humidity"] + " %";
                        mClima.Visibilidad = (string)datos["weather"][0]["main"];

                        var fechaBase = new DateTime(1970, 1, 1, 0, 0, 0, 0);
                        var amanecer = fechaBase.AddSeconds((double)datos["sys"]["sunrise"]);
                        var ocaso = fechaBase.AddSeconds((double)datos["sys"]["sunset"]);
                        mClima.Amanecer = amanecer.ToString() + " UTC";
                        mClima.Atardecer = ocaso.ToString() + " UTC";

                        return mClima;
                    }

                }

            }
            return default(ClimaApp.Clases.Clima);
        }
    }
}
