$(document).ready(function () {
    $(".sillaOcupada").hover(function () {
        $("#lblSilla").text(this.id + ": ");
        $("#lblInfo").text("Ocupada");
        $("#lblInfo").css("color", "#E31937");
    },
        function () {
            $("#lblSilla").text("");
            $("#lblInfo").text("");
        });

    $(".sillaDisponible").hover(function () {
        $("#lblSilla").text(this.id + ": ");
        $("#lblInfo").text("Disponible");
        $("#lblInfo").css("color", "#5734CE");
    },
        function () {
            $("#lblSilla").text("");
            $("#lblInfo").text("");
        });

    $(".sillaSeleccionada").hover(function () {
        $("#lblSilla").text(this.id + ": ");
        $("#lblInfo").text("Seleccionada");
        $("#lblInfo").css("color", "#80798D");
    },
        function () {
            $("#lblSilla").text("");
            $("#lblInfo").text("");
        });

    $("button").click(function () {
        var clase = this.className;
        switch (clase) {
            case "sillaDisponible":
                $("#lblSilla").text(this.id + ": ");
                $("#lblInfo").text("Seleccionada");
                $("#lblInfo").css("color", "#80798D");
                //this.className = "sillaSeleccionada";
                var id = document.getElementById(this.id);
                $(id).removeClass("sillaDisponible");
                //$(id).addClass("sillaSeleccionada");
                //removeClass("sillaDisponible");
                //document.getElementById(this.id).addClass("sillaSeleccionada");
                alert(id.className);
                break;
            case "sillaSeleccionada":
                $("#lblSilla").text(this.id + ": ");
                $("#lblInfo").text("Disponible");
                $("#lblInfo").css("color", "#5734CE");
                this.className = "sillaDisponible";
                //alert(this.className);
                break;
            case "sillaOcupada":
                return false;
                break;
        }
    });
});