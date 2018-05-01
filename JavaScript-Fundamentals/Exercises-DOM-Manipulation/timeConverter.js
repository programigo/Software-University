function attachEventsListeners() {
    document.getElementById('daysBtn').addEventListener('click', convertFromDays);
    document.getElementById('hoursBtn').addEventListener('click', convertFromHours);
    document.getElementById('minutesBtn').addEventListener('click', convertFromMinutes);
    document.getElementById('secondsBtn').addEventListener('click', convertFromSeconds);

    let days = document.getElementById('days');
    let hours = document.getElementById('hours');
    let minutes = document.getElementById('minutes');
    let seconds = document.getElementById('seconds');


    function convertFromDays() {
        hours.value = Number(days.value) * 24;
        minutes.value = Number(hours.value) * 60;
        seconds.value = Number(minutes.value) * 60;
    }

    function convertFromHours() {
        days.value = Number(hours.value) / 24;
        minutes.value = Number(hours.value) * 60;
        seconds.value = Number(minutes.value) * 60;
    }

    function convertFromMinutes() {
        days.value = Number(minutes.value) / 1440;
        hours.value = Number(days.value) * 24;
        seconds.value = Number(minutes.value) * 60;
    }

    function convertFromSeconds() {
        days.value = Number(seconds.value) / 86400;
        hours.value = Number(days.value) * 24;
        seconds.value = Number(minutes.value) * 60;
        minutes.value = Number(hours.value) * 60;
    }
}