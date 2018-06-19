function ShowMessage() {
    console.log($('#txtInput').val());
}

$('#btnClick1').on('click', function (e) {
    console.clear();
    console.log('btnClick1: click');

    var elemArea = document.getElementById('area');
    var startX = 308;
    var startY = 308;
    var endX = 508;
    var endY = 508;

    for (var i = startX; i <= endX; i++) {
        for (var j = startY; j <= endY; j++) {
            if (i == startX && j == startY)
                MouseClick(document, 'mousedown', i, j);
            else if (i == endX && j == endY)
                MouseClick(document, 'mousedown', i, j);
            else
                MouseClick(document, 'mousemove', i, j);
        }
    }

    //MouseClick(document, 'mousedown', 308, 308);
});

$('#btnClick2').on('click', function (e) {
    console.log('btnClick2: click');
});

$('#btnClick2').on('mousedown', function (e) {
    console.log('btnClick2: mousedown');
});

$('#btnClick2').on('mouseup', function (e) {
    console.log('btnClick2: mouseup');
});

$('#btnClick3').on('click', function (e) {
    console.log('btnClick3: click');
});

$('#btnClick3').on('mousedown', function (e) {
    console.log('btnClick2: mousedown');
});

$('#btnClick3').on('mouseup', function (e) {
    console.log('btnClick3: mouseup');
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
    //console.log(eventType);
    //console.log(_element);
}

function MouseMove(element, eventType, startX, startY, endX, endY) {
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
    //console.log(eventType);
    //console.log(_element);
}