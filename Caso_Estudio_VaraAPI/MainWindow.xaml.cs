using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Caso_Estudio_VaraAPI
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Varamiento nuevoVaramiento = new Varamiento() {
                nombreInformante = tbNombreInformante.Text,
                telefonoInformante = tbTelefono.Text,
                direccionInformante = tbDireccion.Text,
                ordenAnimal = cbOrden.Text,
                condicionAnimal = cbCondicion.Text,
                numeroAnimales = Int16.Parse(tbNumeroAnimales.Text),
                observaciones = tbObservaciones.Text,
                facilAcceso = chbAcceso.IsChecked.Value,
                acantilado = chAcantilado.IsChecked.Value,
                sustrato = cbSustrato.Text,
                primeraVezVisto = cbVistoen.Text,
                fechaAvistamiento = tbFecha.Text,
                pais = tbPais.Text,
                estado = tbEstado.Text,
                ciudad = tbCiudad.Text,
                localidad = tbLocalidad.Text,
                informacionAdicionalUbicacion = tbInfAdicional.Text,
                latitud = tbLatitud.Text,
                longitud = tbLongitud.Text
            };

            registrar(nuevoVaramiento);
        }


        void registrar(Varamiento varamiento)
        {
            string url = "http://ec2-3-137-222-34.us-east-2.compute.amazonaws.com/yo/varamientos";

            
            string resultado = "";

            WebRequest request = WebRequest.Create(url);
            request.Method = "post";
            request.ContentType = "application/json";
            request.Headers.Add("Authorization", "Bearer eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJmcmVzaCI6dHJ1ZSwiaWF0IjoxNjM3NDQ2NDExLCJqdGkiOiIwYTM2OWVjYS1lMmZiLTRlNzctOTAwOC04ZDc0ZGI3ODRhMDEiLCJ0eXBlIjoiYWNjZXNzIiwic3ViIjoiOTA3MDM1YWItZGNmYi00NmJhLWIzNWItZDI5YmFlNGM3NTgxIiwibmJmIjoxNjM3NDQ2NDExLCJleHAiOjE2Mzc0NjgwMTF9.QxnFyc5tdPpphprAZVFMhGRXYvVGoqQ6xgCOubnKM_c");

            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                string json = JsonConvert.SerializeObject(varamiento);
                streamWriter.Flush();
                streamWriter.Close();
            }

            WebResponse wResponse = request.GetResponse();

            using (var streamReader = new StreamReader(wResponse.GetResponseStream()))
            {
                resultado = streamReader.ReadToEnd().Trim();
            }
        }
    }
}
