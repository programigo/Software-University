function parse(input) {
    let json = {};
    let appPattern = /[$|&]app\s*='(.*?)'/;
    let controllerPattern = /\$controller\s*='(.*?)'/;
    let modelPattern = /\$model\s*='(.*?)'/;
    let viewPattern = /\$view\s*='(.*?)'/;

    let appMatch;
    let controllerMatch;
    let modelMatch;
    let viewMatch;

    for (let row of input) {
        appMatch = appPattern.exec(row);
        controllerMatch = controllerPattern.exec(row);
        modelMatch = modelPattern.exec(row);
        viewMatch = viewPattern.exec(row);

        if (!json.hasOwnProperty(appMatch[1]) && appMatch != null) {
            json[appMatch[1]] = {};
        }

        if (!json[appMatch[1]].hasOwnProperty(['controllers'])) {
            json[appMatch[1]]['controllers'] = [];
        }

        if (controllerMatch != null) {
            json[appMatch[1]]['controllers'].push(controllerMatch[1]);
        }

        if (!json[appMatch[1]].hasOwnProperty(['models'])) {
            json[appMatch[1]]['models'] = [];
        }

        if (modelMatch != null) {
            json[appMatch[1]]['models'].push(modelMatch[1]);
        }

        if (!json[appMatch[1]].hasOwnProperty(['views'])) {
            json[appMatch[1]]['views'] = [];
        }

        if (viewMatch != null) {
            json[appMatch[1]]['views'].push(viewMatch[1]);
        }
    }

    let res = Object.keys(json).sort(function (a, b) {
        let firstAppControllersCount = json[a]['controllers'].length;
        let secondAppControllersCount = json[b]['controllers'].length;

        let result = secondAppControllersCount - firstAppControllersCount;

        if (result === 0) {
            let firstAppModelsCount = json[a]['modules'].length;
            let secondAppModelsCount = json[b]['modules'].length;

            result = secondAppModelsCount - firstAppModelsCount;
        }

        return result;
    });

    let finalResult = '{';

    for (var i = 0; i < res.length; i++) {

        let au = json[res[i]];

        finalResult += `${res[i]}: ${JSON.stringify(au)}, `;
    }

    finalResult += '}';


    console.log(finalResult);
}

parse(['$controller=\'PHPController\'&app=\'Language Parser\'',
'$app=\'Garbage Collector\'',
'$controller=\'GarbageController\'&app=\'Garbage Collector\'',
'$controller=\'SpamController\'&app=\'Garbage Collector\'',
'$app=\'Language Parser\'']);