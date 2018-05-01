function getInfo (name, age, weight, height) {
    let heightInMeters = height / 100;
    let patient = {
        name: name,
        personalInfo: {
            age: age,
            weight: weight,
            height: height
        },
        BMI: Math.round(weight / (heightInMeters * heightInMeters))
    };

    getStatus(patient.BMI);

    if (patient.status === 'obese') {
        patient.recommendation = 'admission required';
    }

    function getStatus(bmi) {
        if (bmi < 18.5) {
            patient.status = 'underweight';
        } else if (bmi < 25) {
            patient.status = 'normal';
        } else if (bmi < 30) {
            patient.status = 'overweight'
        } else if (bmi >= 30) {
            patient.status = 'obese';
        }
    }

    return patient;
}

console.log(getInfo('Peter', 29, 75, 182));
