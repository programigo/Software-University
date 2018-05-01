function attachEvents() {
    const URL = 'https://judgetests.firebaseio.com/';
    const CURRENT = $('#current');
    const UPCOMING = $('#upcoming');
    const SYMBOLS = {
        Sunny: '&#x2600',
        PartlySunny: '&#x26C5',
        Overcast: '&#x2601',
        Rain: '&#x2614',
        Degrees: '&#176'
    };

    $('#submit').on('click', getWeather);

    function getWeather() {
        $('#forecast').show();
        $.ajax({
            method: 'GET',
            url: URL + 'locations.json'
        }).then(loadLocations)
            .catch(displayError);
    }

    function loadLocations (locations) {
        let enteredLocation = $('#location').val();
        let obj = locations.find(location => location.name === enteredLocation);
        let code = obj.code;
        $.ajax({
            method: 'GET',
            url: URL + `forecast/today/${code}.json`
        }).then(displayTodayWeather)
            .catch(displayError);

        $.ajax({
            method: 'GET',
            url: URL + `forecast/upcoming/${code}.json`
        }).then(displayUpcomingWeather)
            .catch(displayError);

        function displayTodayWeather(weatherInfo) {
            $('.condition').empty();
            CURRENT.append($(`<span class="condition symbol">${SYMBOLS[weatherInfo['forecast'].condition]}</span>`));
            let conditionSpan = $('<span class="condition">');
            conditionSpan.append($(`<span class="forecast-data">${weatherInfo.name}</span>`));
            conditionSpan.append($(`<span class="forecast-data">${weatherInfo['forecast'].low}${SYMBOLS.Degrees}/${weatherInfo['forecast'].high}${SYMBOLS.Degrees}</span>`));
            conditionSpan.append($(`<span class="forecast-data">${weatherInfo['forecast'].condition}</span>`));
            CURRENT.append(conditionSpan);
        }

        function displayUpcomingWeather(weatherInfo) {
            $('.upcoming').empty();
            for (let currentDayInfo of weatherInfo['forecast']) {
                let upcomingSpan = $('<span class="upcoming">');
                if (currentDayInfo.condition === 'Partly sunny') {
                    upcomingSpan.append($(`<span class="symbol">${SYMBOLS.PartlySunny}</span>`));
                } else {
                    upcomingSpan.append($(`<span class="symbol">${SYMBOLS[currentDayInfo.condition]}</span>`));
                }
                upcomingSpan.append($(`<span class="forecast-data">${currentDayInfo.low}${SYMBOLS.Degrees}/${currentDayInfo.high}${SYMBOLS.Degrees}</span>`));
                upcomingSpan.append($(`<span class="forecast-data">${currentDayInfo.condition}</span>`));
                UPCOMING.append(upcomingSpan);
            }
        }
    }

    function displayError(err) {

    }
}