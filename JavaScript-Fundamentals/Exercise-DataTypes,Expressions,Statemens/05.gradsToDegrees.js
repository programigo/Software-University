function calculateDegree(grad) {
    grad = grad % 400;
    let degree = 0.9 * grad;

    let degreeOutput = degree > 0 ? degree : 360 + degree;

    return degreeOutput;
}

calculateDegree(400);