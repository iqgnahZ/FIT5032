function generateCalendar() {
    $('#calendar').fullCalendar({
        defaultView: 'month',
        contentHeight: 500,
        businessHours: true,
        header: {
            left: "month, agendaWeek, today",
            center: "title",
            right: "prev,next"
        },
        list: list
    }); }
