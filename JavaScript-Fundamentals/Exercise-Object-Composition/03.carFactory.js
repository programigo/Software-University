function createCar(baseCar) {
    let engines = {
        Small: {power: 90, volume: 1800},
        Normal: {power: 120, volume: 2400},
        Monster: {power: 200, volume: 3500}
    };

    let allEngines = Object.keys(engines).map(function(key) {
        return engines[key];
    });

    let carriages = {
        Hatchback: {type: 'hatchback', color: `${baseCar.color}`},
        Coupe: {type: 'coupe', color: `${baseCar.color}`}
    };

    let allCariages = Object.keys(carriages).map(function(key) {
        return carriages[key];
    });

    let wheelSize = baseCar.wheelsize % 2 === 0 ? baseCar.wheelsize - 1 : baseCar.wheelsize;

    return {
        model: `${baseCar.model}`,
        engine: allEngines.find(e => e.power >= baseCar.power),
        carriage: allCariages.find(c => c.type === baseCar.carriage),
        wheels: [wheelSize, wheelSize, wheelSize, wheelSize]
    };
}

console.log(createCar({ model: 'VW Golf II',
    power: 90,
    color: 'blue',
    carriage: 'hatchback',
    wheelsize: 14 }
));