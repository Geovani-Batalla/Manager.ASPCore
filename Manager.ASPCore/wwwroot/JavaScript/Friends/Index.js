function LoadImages() {
    $.ajax({
        url: BaseUrl + 'Friends/GetFiles',
        type: "POST",
        dataType: "json",
        beforeSend: function (a) {
        },
        cache: false,
        async: true,
        success: function (result) {
            try {
                if (result.code == 400) {
                    var aux = "'";
                    for (var i = 0; i < result.result.dropBoxFiles.length; i++) {

                        if (result.result.dropBoxFiles[i].isShowable) {
                            var html = '<div class="col-sm-6 col-md-6">' +
                                           '<a href="#" class="thumbnail">' +
                                               '<img width="100" height="100" alt="star" onclick="DownloadFile(' + '' + aux + '' + result.result.dropBoxFiles[i].filePath + '' + aux + '' + ')" '+
                                               'src = "data:image/gif;base64,' + result.result.dropBoxFiles[i].file + '" /> ' +
                                            '</a>' +
                                       '</div>';

                            $("#RowThumbnail").append(html);
                        }
                        else {
                            var html = '<div class="col-sm-12 col-md-12">' +
                                           ' <a style="color:blue; text-decoration:underline" href="#" onclick="DownloadFile(' + '' + aux + '' + result.result.dropBoxFiles[i].filePath + '' + aux + '' + ')"> ' +
                                           '' + result.result.dropBoxFiles[i].fileName + '' +
                                           '</a >' +
                                       '</div>';
                            $("#RowDocs").append(html);

                        }
                    }
                }
            } catch (e) {
                console.log(e);
            }
        }
    });
}

function DownloadFile(Files) {
    window.location = '/Friends/Download?file=' + Files;
}