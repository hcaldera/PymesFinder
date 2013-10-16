using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace piti2013.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Mapa = iniciaMapa();

            return View();
        }

        public string iniciaMapa()
        {
            return @"
                <script type='text/javascript'>
                    function informacion(coordenadas) 
                        {
	                    $('#latitude').html(coordenadas.Lat);
	                    $('#longitude').html(coordenadas.Lng);
	                    }

	                function initialize() 
                        {  
	                    var coordenadas = {Lat: 0, Lng: 0};

	                    function localizacion(posicion) 
                            {
	                        coordenadas = {Lat: posicion.coords.latitude, Lng: posicion.coords.longitude}

	                        informacion(coordenadas);

	                        var mapOptions = 
                                {
	                            zoom: 16,
	                            center: new google.maps.LatLng(coordenadas.Lat, coordenadas.Lng),
	                            disableDefaultUI: true,
	                            mapTypeId: google.maps.MapTypeId.ROADMAP
	                            }

	                        var map = new google.maps.Map(document.getElementById('mapa'), mapOptions);

	                        var infowindow = new google.maps.InfoWindow(
                                {
	                            map: map,
	                            position: new google.maps.LatLng(coordenadas.Lat, coordenadas.Lng),
	                            content: 'Tu ubicación usando HTML5.'
	                            });"

                            + direcciones() +
                            	                        
	                        @"}

	                    function errores(error) {alert('Ha ocurrido un error al obtener la información');}

	                    if (navigator.geolocation) {navigator.geolocation.getCurrentPosition(localizacion, errores);}
                        else {alert('Tu navegador no soporta la Geolocalización');}
	                    }
                </script>";
        }

        public string direcciones()
        {
            return @"var image = 'http://www.goldiumcruceros.com/imagenes/icono_facebook.gif';

                     var marker = new google.maps.Marker(
                        {
	                    position: new google.maps.LatLng(31.63539, -106.4011213),
	                    map: map,
	                    title: 'Hello World3!',
                        icon:image
	                    });

                     var marker = new google.maps.Marker(
                        {
	                    position: new google.maps.LatLng(31.62539, -106.4011213),
	                    map: map,
	                    title: 'Hello World3!',
                        icon:image
	                    });";
        }
    }
}
