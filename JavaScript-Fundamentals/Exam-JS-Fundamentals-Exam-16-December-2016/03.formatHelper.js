function repairText(input) {
    let mainPattern = /\w*([.,!?:;] )/;
    let mainPatternMatch = mainPattern.exec(input[0]);

    while (mainPatternMatch != null) {
        input[0] = input[0].replace(/\s+[.,!?:;]\s+/, mainPatternMatch[1]);

        mainPatternMatch = mainPattern.exec(input[0]);
    }

    let a = '';
}

repairText(['Terribly formatted text . With ,       chaotic spacings   . " Terrible quoting "! Also this date is pretty confusing : 20 . 12. 16 .']);