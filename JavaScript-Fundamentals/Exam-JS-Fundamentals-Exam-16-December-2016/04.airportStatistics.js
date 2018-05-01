function showAirportInfo(arr) {
    let finalInfo = {};

    for (let planeInfo of arr) {
        let currentPlaneInfo = planeInfo.split(/\s*/);
        let planeId = currentPlaneInfo[0];
        let town = currentPlaneInfo[1];
        let passengersCount = Number(currentPlaneInfo[2]);
        let action = currentPlaneInfo[3];

        if (finalInfo.hasOwnProperty(planeId)) {
            if (finalInfo[planeId]) {
                
            }
        }
    }
}

showAirportInfo(["Boeing474 Madrid 300 land",
    "AirForceOne WashingtonDC 178 land",
    "Airbus London 265 depart",
    "ATR72 WashingtonDC 272 land",
    "ATR72 Madrid 135 depart"]);