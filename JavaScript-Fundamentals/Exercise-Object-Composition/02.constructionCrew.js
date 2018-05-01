function modifyWorker(worker) {

    if (worker.handsShaking === true) {
        worker.bloodAlcoholLevel = (worker.weight * 0.1 * worker.experience) + worker.bloodAlcoholLevel;
        worker.handsShaking = false;
    }

    return worker;
}

console.log(modifyWorker({
        weight: 80,
        experience: 1,
        bloodAlcoholLevel: 0,
        handsShaking: true
    }
));