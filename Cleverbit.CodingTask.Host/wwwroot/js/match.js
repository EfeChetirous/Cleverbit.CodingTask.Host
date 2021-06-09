$(function () {

    refresh();

    function generateRow(rowData) {
        var winnerName = "";
        if (rowData.firstUserPoint > rowData.secondUserPoint) {
            winnerName = rowData.firstUser.username;
        }
        else {
            winnerName = rowData.secondUser.username;
        }
        $("#MatchTableRows").append("<tr> <td> " + rowData.firstUser.username + "</td><td> " + rowData.secondUser.username + "</td><td> " + rowData.firstUserPoint + "</td><td> " + rowData.secondUserPoint + "</td><td> " + winnerName + "</td> <td> " + rowData.matchEndDate + "</td> <tr>")
    }

    function refresh() {
        $.ajax({
            type: "get",
            url: baseUrl + "/Ping/GetUserMatches",
            processdata: false,
            contenttype: false,
            datatype: "json",
            success: function (data) {
                for (var index = 0; index < data.length; index++) {
                    generateRow(data[index]);
                }
            },
            error: function (data) {
                alert("An error has been occured!");
            }
        })
    }

    function clearRows() {
        $("#MatchTableRows").html("");
    }

    $("#btnRefresh").click(function (e) {
        clearRows();
        refresh();
    })

    $("#btnLogin").click(function (e) {
        if ($("#inpUserName").val() === "" || $("#inpPassword").val() === "") {
            alert("Username and Pasword are required fields!")
            return;
        }

        var authenticateModel = { Username: $("#inpUserName").val(), Password: $("#inpPassword").val() };
        $.ajax({
            type: "post",
            url: baseUrl + "/Ping/Authenticate",
            processdata: false,
            contenttype: false,
            data: authenticateModel,
            datatype: "json",
            success: function (user) {
                if (user !== null && user != undefined) {
                    $("#formLogin").addClass("d-none");
                    $("#divUsername").removeClass("d-none");
                    $("#lblUsername").text(user.username);
                    $("#divPlay").removeClass("d-none");
                }
                else {
                    $("#formLogin").removeClass("d-none");
                    $("#lblUsername").addClass("d-none");
                    $("#lblUsername").text("");
                    $("#divPlay").addClass("d-none");
                }
            },
            error: function (data) {
                alert("An error has been occured!");
            }
        });
    })

    $("#btnPlay").click(function (e) {
        $.ajax({
            type: "get",
            url: baseUrl + "/Ping/GetRandomNumber",
            processdata: false,
            contenttype: false,
            datatype: "json",
            beforeSend: function (xhr) {
                xhr.setRequestHeader("Authorization", "Basic " + btoa($("#inpUserName").val() + ":" + $("#inpPassword").val()));
            },
            success: function (data) {
                $("#lblRandomNumber").text(data);
                $("#btnPlay").addClass("d-none");
                clearRows();
                rekfresh();
            },
            error: function (data) {
                alert("An error has been occured!");
            }
        })
    })
});