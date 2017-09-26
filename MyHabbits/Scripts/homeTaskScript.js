$(document).ready(function () {
    $('.add').on('click', function () {
        var seconds = $(this).data('seconds');
        var Id = $(this).data('id')
        console.log("Id: " + $(this).data('id'));
        
        var updateTask = {
            "Id": Id
        };

        $.ajax({
            url: "Home/Update/",
            method: "POST",
            data: { eTask: updateTask , secondsCompleted: seconds},
            success: function (res) {
                console.log("Task Updated!");
                location.reload();
            },
            error: function (res) {
                console.log("Something Went Wrong. Cannot update id: " + Id);
            }
        });

    });
});