function CloseModal() {
    var calendarModal = document.getElementById("calendar-modal");  
    if (calendarModal) {
        var modal = bootstrap.Modal.getInstance(calendarModal)
        if (modal) {
            modal.hide();  
        }
    }
} 

function CloseModalById(modalId) {
    var calendarModal = document.getElementById(modalId);
    if (calendarModal) {
        var modal = bootstrap.Modal.getInstance(calendarModal)
        if (modal) {
            modal.hide();
        }
    }
}