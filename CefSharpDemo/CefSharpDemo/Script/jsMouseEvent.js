< !DOCTYPE html >
    <html>
        <head>
            <meta charset=utf - 8 />
                <title>JS Bin</title>
                <script src="jquery.min.js"></script>
</head>
<body>
                <div id="area" style="width: 1000px; height: 1000px; background-color:blue; position: relative;">
                    <input type="button" id="btnClick" value="Click me !!!" style="width: 100px; height: 50px" />
                    <input type="text" id="txtInput" placeholder="Input something" style="width: 200px; height: 44px" />
                    <input type="button" id="btnClick2" value="!!!" style="width: 50px; height: 50px; left: 100px; top: 100px; position: absolute;" />
                </div>

                <script>
                    function ShowMessage(){
                        console.log($('#txtInput').val());
                    }

	$('#btnClick').off('click').on('click', function(e){
                        console.clear();

                    var elemArea = document.getElementById('area');
		MouseClick(document, 'mousedown', 108, 108);
	});

	$('#btnClick2').off('click').on('click', function(e){
                        console.log('click');
                    });

	$('#btnClick2').off('mousedown').on('mousedown', function(e){
                        console.log('mousedown');
                    });

	$('#btnClick2').off('mouseup').on('mouseup', function(e){
                        console.log('mouseup');
                    });

	function MouseClick(element, eventType, clientX, clientY) {
		var event = document.createEvent('MouseEvents');
		var _element = document.elementFromPoint(clientX, clientY);
		event.initMouseEvent(
		/*type*/ eventType,
		/*canBubble*/ true,
		/*cancelable*/ true,
		/*view*/ window,
		/*detail*/ 0,
		/*screenX*/ 0,
		/*screenY*/ 0,
		/*clientX*/ clientX,
		/*clientY*/ clientY,
		/*ctrlKey*/ false,
		/*altKey*/ false,
		/*shiftKey*/ false,
		/*metaKey*/ false,
		/*button*/ 3,
		/*relatedTarget*/ null);

		_element.dispatchEvent(event);
		console.log(_element);
	}
  </script>
            </body>
</html>
