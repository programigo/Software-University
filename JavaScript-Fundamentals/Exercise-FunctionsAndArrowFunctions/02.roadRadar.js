function checkDriver(input) {
    let speed = input[0];
    let area = input[1];

    let limit = getLimit(area);
    let infraction = getInfraction(speed, limit);

    if (infraction){
        console.log(infraction);
    }

    function getLimit(zone) {
        var limitSpeed;

        switch (zone){
            case 'motorway': limitSpeed = 130; break;
            case 'interstate': limitSpeed = 90; break;
            case 'city': limitSpeed = 50; break;
            case 'residential': limitSpeed = 20; break;
        }
        
        return limitSpeed;
    }
    
    function getInfraction(speed, limit) {
        let overSpeed = speed - limit;
        let infractionInfo;

        if (overSpeed <= 0){
            return false;
        } else {
            if (overSpeed >= 1 && overSpeed <= 20) {
                infractionInfo = 'speeding';
            } else if (overSpeed >= 21 && overSpeed <= 40) {
                infractionInfo = 'excessive speeding';
            } else {
                infractionInfo = 'reckless driving';
            }
        }

        return infractionInfo;
    }
}

checkDriver([40, 'city']);