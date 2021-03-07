

var LoadMenu = function (id) { // произвести загрузку меню 

    $('#preloader').show();
    $.get("/Home/GetMenu/" + id, function (data) {
        $('#preloader').hide();
        ParseMenu(data, id);
    });
}

var ParseMenu = function (menu, id) { //разбор меню на части 
    var root = $('<ul />');
    root.addClass('menu');
    root.attr("id", menu.Id);

    var itemRoot = $('<li/>');
    
    var caret = $('<span/>');
    caret.addClass('caret-menu');
    caret.attr("id", "sp-" + menu.Id);
    caret.bind('click', updateState);
     
    var link = $('<a />');
    link.attr("href", "#");
    link.text(menu.Name);
    link.bind("click", function () {
        eval(menu.FunJs);
    });


    itemRoot.append(caret);
    itemRoot.append(link);
    root.append(itemRoot);


    $('#' + menu.Id).remove();
    $('#container-menu-' + menu.Id).append(root);
    traverse(menu, process);
    caret.click(); // вызов выпадение меню 
}

var updateState = function () {
    $(this).toggleClass("caret-menu-down");
    var queryId = $(this).attr('id');
    var rootId = queryId.slice(3, queryId.lenght);
    $("#" + rootId + "> ul").toggleClass("active");
}



function process(DomId, data) { // обработка 1 пункта 

    if ((typeof (data) == "undefined") || data.length == 0)
        return;

    var list = $('<ul />');
    list.addClass('nested');

    $.each(data, function (index, item) {

        var listItem = $("<li/>");
        listItem.attr("id", item.Id);

        if (item.Children.length > 0) {

            var caret = $("<span />");
            caret.addClass('caret-menu');
            caret.attr("id", "sp-" + item.Id);
            caret.bind('click', updateState);
            listItem.append(caret);
        }

        if (item.FunJs != null) {
            var link = $("<a />");
            link.attr("href", "#");
            link.text(item.Name);

            link.bind("click", function () {
                eval(item.FunJs);
            });

            listItem.append(link);
        }
        else {
            listItem.text(item.Name);
        }

        list.append(listItem);
    });
    $('#' + DomId).append(list);
}

function traverse(o, func) { //рекурсивный обход
    for (var i in o) {

        if (o[i] !== null && typeof (o[i]) == "object") {
            func.apply(this, [o["Id"], o["Children"]]); // если массив вызов
            traverse(o[i], func);
        }
    }
}


