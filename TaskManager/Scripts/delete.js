$(document).ready(
            (function () {
                $.ajaxSetup({ cache: true });
                $("#container").on("click", ".delItem", function (e) {
                    var button = $(this);
                    e.preventDefault();
                    bootbox.confirm("Are you sure you want to delete this task?", function (result) {
                        if (result) {
                            $.ajax({
                                url: "api/DeleteApi/" + button.attr("data-task-id"),
                                method: "DELETE",
                                success: function () {
                                    button.parents("form").remove();
                                    window.location.replace("https://localhost:44355/");
                                }
                            });
                        }
                    });  
                });
            }));