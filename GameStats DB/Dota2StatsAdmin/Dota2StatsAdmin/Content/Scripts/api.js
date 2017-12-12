var uri = 'http://localhost:57732/Dota2Stats/';

var Api = Api || {

};
function get(tableName, id) {
    return $.ajax({
        url: uri + tableName + '/' + id,
        type: 'GET'
    });
}

function getAll(tableName) {
    return $.ajax({
        url: uri + tableName + '/',
        type: 'GET'
    });
}

function add(tableName, item) {
    return $.ajax({
        url: uri + tableName + '/',
        type: 'POST',
        contentType: 'application/json',
        data: JSON.stringify(item)
    });
}

function edit(tableName, id, item) {
    return $.ajax({
        url: uri + tableName + '/' + id,
        type: 'PUT',
        contentType: 'application/json',
        data: JSON.stringify(item)
    });
}

function remove(tableName, id) {
    return $.ajax({
        type: 'DELETE',
        url: uri + tableName + '/' + id,
        contentType: 'application/x-www-form-urlencoded; charset=utf-8'
    });
}