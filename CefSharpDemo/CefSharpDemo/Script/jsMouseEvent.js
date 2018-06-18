function triggerMouseEvent(node, eventType, x, y) {
    if (x == undefined) {
        x = node.offsetLeft;
    }
    if (y == undefined) {
        y = node.offsetTop;
    }
    var clickEvent = document.createEvent('MouseEvents');
    clickEvent.initEvent(
        eventType,
        true /* bubble */,
        true /* cancelable */,
        window, null,
        x, y, 0, 0, /* coordinates */
        false, false, false, false, /* modifier keys */
        0 /*left*/,
        null);
    node.dispatchEvent(clickEvent);
}

//function triggerMouseEvent(x, y) {
//    var ev = document.createEvent("MouseEvent");
//    var el = document.elementFromPoint(x, y);
//    ev.initMouseEvent(
//        "click",
//        true /* bubble */, true /* cancelable */,
//        window, null,
//        x, y, 0, 0, /* coordinates */
//        false, false, false, false, /* modifier keys */
//        0 /*left*/, null
//    );
//    el.dispatchEvent(ev);
//}

function triggerMouseEvent(node, eventType, x, y) {
    var clickEvent = document.createEvent('MouseEvents');
    if (x == undefined || y == undefined) {
        clickEvent.initEvent(
            eventType,
            true /* bubble */,
            true /* cancelable */);
    }
    else {
        clickEvent.initEvent(
            eventType,
            true /* bubble */,
            true /* cancelable */,
            window, null,
            x, y, 0, 0, /* coordinates */
            false, false, false, false, /* modifier keys */
            0 /*left*/,
            null);
    }
    node.dispatchEvent(clickEvent);
}