(function() {
    let solution = {
        add: function (vec1, vec2) {
            let xa = vec1[0];
            let xb = vec2[0];
            let ya = vec1[1];
            let yb = vec2[1];
            let result = [];
            result.push(xa + xb);
            result.push(ya + yb);

            return result; //`[${xa + xb}, ${ya + yb}]`;
        },

        multiply: function (vec1, scalar) {
            let xa = vec1[0];
            let ya = vec1[1];
            let result = [];
            result.push(xa * scalar);
            result.push(ya * scalar);

            return result; //`[${xa * scalar}, ${ya * scalar}]`;
        },

        length: function (vec1) {
            let xa = vec1[0];
            let ya = vec1[1];

            return Math.sqrt(xa * xa + ya * ya);
        },

        dot: function (vec1, vec2) {
            let xa = vec1[0];
            let xb = vec2[0];
            let ya = vec1[1];
            let yb = vec2[1];

            return xa * xb + ya * yb;
        },

        cross: function (vec1, vec2) {
            let xa = vec1[0];
            let xb = vec2[0];
            let ya = vec1[1];
            let yb = vec2[1];

            return xa * yb - ya * xb;
        }
    };

    return solution;
})();