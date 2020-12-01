// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

//import { data } from "jquery";

// Write your JavaScript code.
function getQuote() {
    $.ajax({
        url: "https://type.fit/api/quotes",
        datatype: 'json',
        type: 'get',
        contentType: 'application/json',
        success: function (data, textStatus, jQxhr) {
            var obj = JSON.parse(data)
            
                $("#Quotes").append(
                    `<tr>
                    <td>${obj[13].author}</td>
                    <td>${obj[13].text}</td>
                </tr>`,
                )
            

            //data.map(function (value) {
            //$("#Quotes").append("<tr><td>" + obj[0].author + obj[0].text + "</td></tr>")
            //})
        },
    });
}
getQuote();
//function getQuote() {
//    const settings = {
//        "async": true,
//        "crossDomain": true,
//        "url": "https://type.fit/api/quotes",
//        "method": "GET"
//    }

//    $.ajax(settings).done(function (response) {
//        const data = JSON.parse(response);
//        console.log(data)
//    });
//}
//getQuote();