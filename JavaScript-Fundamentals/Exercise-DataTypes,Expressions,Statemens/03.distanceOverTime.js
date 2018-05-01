function calculateDistance(input) {
    let V1 = input[0];
    let V2 = input[1];
    let T = input[2];

    let v1InMeters = V1 / 3.6;
    let v2InMeters = V2 / 3.6;

    let dist1 = v1InMeters * T;
    let dist2 = v2InMeters * T;

    let delta = Math.abs(dist1 - dist2);

    return delta;
}

console.log(calculateDistance([5, -5, 40]));