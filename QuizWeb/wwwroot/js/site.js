function ToggleVisibility(id) {
    $("#" + id).fadeToggle();
    $("#" + id).toggleClass("hidden-element");
}