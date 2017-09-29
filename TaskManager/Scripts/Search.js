$(function () {
    $('.link').click(function () {
        var search = $("#search").val();
        var type = $("#list option:selected").val();
        this.href = this.href.replace("searchValue", search);
        this.href = this.href.replace("typeValue", type);
    });
});