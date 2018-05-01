function dayOfWeek(day) {
    let days = ['Monday', 'Tuesday', 'Wednesday', 'Thursday', 'Friday', 'Saturday', 'Sunday'];

    let index = days.indexOf(day);

    return index > -1 ? index + 1 : 'error';
}