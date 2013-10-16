//<![CDATA[ 

var seleccionado;
var bordeInicial;
var fondoImagen = false;
var colorTextoInicial;
var colorDeBorde;

function imprimir()
	{
	window.print();
	}

function enfrenteAtras(tipoNumero)
	{
	if(seleccionado != null)
		seleccionado.style.zIndex = tipoNumero.value;
	else
		 tipoNumero.value = 20;
	
	}
function colorBorde()
	{
	if(seleccionado != null)
		seleccionado.style.borderColor = colorDeBorde = document.getElementById('btnColor').value;
	}


function tamañoPublicidad()
	{
	var tamañoContenedor = document.getElementById('tamañoContenedor');
	
	switch(tamañoContenedor.selectedIndex)
		{
		case 0:	document.getElementById('contenedor').style.height = 189 + 'px';
				document.getElementById('contenedor').style.width = 345 + 'px';
				break;	
		
		case 1:	document.getElementById('contenedor').style.height = 500 + 'px';
				document.getElementById('contenedor').style.width = 500 + 'px';
				break;
		
		case 2:	document.getElementById('contenedor').style.height = 800 + 'px';
				document.getElementById('contenedor').style.width = 800 + 'px';
				break;
		
		default: window.alert('Error inesperado, contacte al administrador del sitio');
		}
	}

function rangoTamañoLetra()
	{
	document.getElementById('etiqueta').textContent =  document.getElementById('rango').value;
	}

function cambiarLetra()
	{	
	if(seleccionado != null)
		{
		if(seleccionado.childNodes[1].nodeName == 'TEXTAREA')
			{
			var fuente = document.getElementById('letra');
			seleccionado.childNodes[0].style.fontFamily = fuente.options[fuente.selectedIndex].text;
			}
		}
	}

function colorLetra()
	{
	if(seleccionado != null)
		{
		if(seleccionado.childNodes[1].nodeName == 'TEXTAREA')
			seleccionado.childNodes[0].style.color = colorTextoInicial = document.getElementById('btnColor').value;
		}
	}


function tamañoLetra()
	{
	if(seleccionado != null)
		{
		if(seleccionado.childNodes[1].nodeName == 'TEXTAREA')
			{
			var fuente = document.getElementById('tamaño');
			seleccionado.childNodes[0].style.fontSize = document.getElementById('rango').value + 'px';
			}
		}
	}

function Eliminar()
	{
	if(seleccionado != null)
		{
		padre = seleccionado.parentNode;
		padre.removeChild(seleccionado);
		seleccionado = null;
		}
	}

function InsertarCajaDeTexto()
	{
	divTexto = document.createElement('div');
	var h3 = document.createElement('h3');
	var textArea = document.createElement('textarea');
	
	divTexto.className = 'ui-widget-content divTextoPublicidad';
	divTexto.style.zIndex = 20;
	divTexto.addEventListener('click',function(event){Seleccion(this); focoTexto(this);});
	divTexto.addEventListener('contextmenu', function(event){QuitarSeleccion(); cambiaTexto(this.childNodes[1]);});
	
	h3.className = 'ui-widget-header h3Publicidad';
	h3.innerText = 'Introduce tu texto';
	h3.style.position = 'relative';
	
	textArea.className = 'ui-widget-header textAreaPublicidad';
	textArea.style.position = 'absolute';
	textArea.addEventListener('blur',function(event){cambiaTexto(this);});
	textArea.addEventListener('keypress', function(event){if (event.keyCode == 13){cambiaTexto(this)}});
	
	divTexto.appendChild(h3);
	divTexto.appendChild(textArea)
	canvas.appendChild(divTexto);
	$(function(){$('.ui-widget-content.divTextoPublicidad').draggable().resizable();});
	}

function rellenoFigura()
	{
	if(seleccionado != null)
		seleccionado.style.backgroundColor = document.getElementById('btnColor').value;
	}
	
function rellenoFondo()
	{
	if(fondoImagen)
		document.getElementById('canvas').removeChild(document.getElementById('fondo'));
		
	var div = document.getElementById('contenedor');
	div.style.backgroundColor = document.getElementById('btnColor').value;
	fondoImagen = false;
	}

function cargaImagen(e)
	{
 	var file = e.target.files[0];
    imageType = /image.*/;
    
    if (!file.type.match(imageType))
    	return;
  
    var reader = new FileReader();
    reader.onload = fileOnload;
    reader.readAsDataURL(file);
      
    function fileOnload(e) 
		{	
		divImagen = document.createElement('div');
		imagen = document.createElement('img');
		
		divImagen.className = 'ui-widget-content divImagenPublicidad';
		divImagen.style.zIndex = 20;
		divImagen.addEventListener('click',function(event){Seleccion(this)});
		divImagen.addEventListener('contextmenu', function(event){QuitarSeleccion();});
		
		imagen.className = 'ui-widget-header imagenLogoPublicidad';
		imagen.src = e.target.result;
		
		divImagen.appendChild(imagen)
		canvas.appendChild(divImagen);
		$(function(){$('.ui-widget-content.divImagenPublicidad').draggable().resizable();});
     	};
    }

function cargaImagenFondo(e)
	{
	if(fondoImagen)
		document.getElementById('canvas').removeChild(document.getElementById('fondo'));
		
	
 	var file = e.target.files[0];
    imageType = /image.*/;
    
    if (!file.type.match(imageType))
    	return;
  
    var reader = new FileReader();
    reader.onload = fileOnload;
    reader.readAsDataURL(file);
      
    function fileOnload(e) 
		{	
		var canvas = document.getElementById('canvas');
		
		imagen = document.createElement('img');
		imagen.className = 'imagenFondo';
		imagen.id = "fondo";
		imagen.style.position= 'absolute';
		imagen.src = e.target.result;
		
		canvas.appendChild(imagen);
		fondoImagen = true;
     	};
    }
  
function Seleccion(div) 
	{
	if(seleccionado != null)
		{
		document.getElementById('frenteAtras').value = div.style.zIndex;
		
		if(colorDeBorde == null)
			seleccionado.style.border = bordeInicial;
		else
			{
			seleccionado.style.border = '1px solid ' + colorDeBorde;	
			}

		
		if(seleccionado.childNodes[1].nodeName == 'TEXTAREA')
			seleccionado.childNodes[1].blur();
		}
	
	bordeInicial = div.style.border;
	seleccionado = div;
	div.style.border = "4px solid";	
	
	}
	
function QuitarSeleccion() 
	{
	if(seleccionado != null)
		{
		if(colorDeBorde == null)
			seleccionado.style.border = bordeInicial;
		else
			{
			seleccionado.style.border = '1px solid ' + colorDeBorde;	
			colorDeBorde = null;
			}
		seleccionado = null;
		}
	}

function focoTexto(div)
	{
	var textArea = div.childNodes[1];
	
	textArea.style.zIndex = 23;
	textArea.value = div.childNodes[0].innerText;
	colorTextoInicial = div.childNodes[0].style.color;
	div.childNodes[0].style.color = 'transparent';
	textArea.style.display = 'inherit';
	textArea.focus();
	}
	
function cambiaTexto(textArea)
	{
	var padre = textArea.parentNode;
	
	if(textArea.value != "")
		padre.childNodes[0].innerText = textArea.value;
	
	padre.childNodes[0].style.color = colorTextoInicial;
	textArea.value = "";
	textArea.style.zIndex = 21;
	textArea.style.display = 'none';
	textArea.blur();
	padre.childNodes[0].focus();
	}

function cuadCircLinea(tipo)
	{
	Dibuja(document.getElementById('canvas'));	
	
	function Dibuja(canvas) 
		{
		var mouse = { x: 0,	y: 0, startX: 0, startY: 0 };
		var element = null;
	
		canvas.onmousemove = function (e) 
			{
			setMousePosition();
			if (element != null) 
				{
				element.style.width = Math.abs(mouse.x - mouse.startX) + 'px';
				element.style.height = Math.abs(mouse.y - mouse.startY) + 'px';
				element.style.left = (mouse.x - mouse.startX < 0) ? mouse.x + 'px' : mouse.startX + 'px';
				element.style.top = (mouse.y - mouse.startY < 0) ? mouse.y + 'px' : mouse.startY + 'px';			
				}
			}
	
		canvas.onclick = function (e) 
			{
			if (element != null) 
				{
				element.addEventListener('click',function(event){Seleccion(this)});
				element = null;
				canvas.style.cursor = "default";
				canvas.onclick = null;				
				} 
			else 
				{	
				mouse.startX = mouse.x;
				mouse.startY = mouse.y;
				
				element = tipo == 'linea' ? document.createElement('hr') : document.createElement('div');
				element.className = tipo;
				element.addEventListener('contextmenu', function(event){QuitarSeleccion();});
				element.style.position = 'absolute';
				element.style.left = mouse.x + 'px';
				element.style.top = mouse.y + 'px';
				element.style.zIndex = 20;
				canvas.appendChild(element);
				$(function(){$('.' + tipo).draggable().resizable();});
				canvas.style.cursor = "crosshair";
				}
			}
		
		function setMousePosition(e) 
			{
			var ev = e || window.event; //Moz || IE
			if (ev.pageX) 
				{ //Moz
				mouse.x = ev.pageX + window.pageXOffset - 8;
				mouse.y = ev.pageY + window.pageYOffset - 34;
				} 
			else if (ev.clientX) 
				{ //IE
				mouse.x = ev.clientX + document.body.scrollLeft - 8;
				mouse.y = ev.clientY + document.body.scrollTop - 34;
				}
			};
		}
	}
