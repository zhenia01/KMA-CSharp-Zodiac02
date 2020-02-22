// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your Javascript code.

$(() => {
    $(".datepicker").datepicker({
        clearBtn: true,
        format: "dd-mm-yyyy",
        endDate: "0d",
        startDate: "-135y",
        weekStart: 1,
        onClose: true,
        immediateUpdates: true,
        keyboardNavigation: false,
        todayBtn: "linked"
    });
})