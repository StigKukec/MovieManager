// *****Genre
var genreArray = [];
var gi = 0;
function saveSelectedGenres(genreDisplayId) {
    document.getElementById('loadedGenres').addEventListener('change', function () {
        var selectedValue = this.selectedIndex;
        var itemId = this.value;
        var selectedText = this.options[selectedValue].text;
        var selectedItem = { value: itemId, text: selectedText };

        const btnDelete = document.createElement('button');
        btnDelete.setAttribute('id', 'btnDeleteGenre' + gi);
        gi++;
        btnDelete.se
        btnDelete.innerText = 'x';

        if (selectedValue < 1 || genreArray.length > 2 || genreArray.some(obj => obj.text === selectedItem.text)) {
            return;
        }

        genreDisplayId.append(selectedItem.text);
        genreDisplayId.appendChild(btnDelete);
        genreArray.push(selectedItem);

        var genreIds = "";
        for (var i = 0; i < genreArray.length; i++) {

            if (i == (genreArray.length - 1)) {
                genreIds += (genreArray[i].value);
            }
            else {
                genreIds += (genreArray[i].value + ",");
            }
        }
        document.getElementById("hiddenGenres").value = genreIds;
    })

    document.getElementById('deleteAllGenres').addEventListener('click', function () {
        genreArray = [];
        gi = 0;
        genreDisplayId.innerHTML = '';
    });
}

// *****Actor
var actorArray = [];
var ai = 0;
function saveSelectedActors(actorDisplayId) {
    document.getElementById('loadedActors').addEventListener('change', function () {
        var selectedValue = this.selectedIndex;
        var itemId = this.value;
        var selectedText = this.options[selectedValue].text;
        var selectedItem = { value: itemId, text: selectedText };

        const btnDelete = document.createElement('button');
        btnDelete.setAttribute('id', 'btnDeleteActor' + ai);
        ai++;
        btnDelete.se
        btnDelete.innerText = 'x';

        if (selectedValue < 1 || actorArray.some(obj => obj.text === selectedItem.text)) {
            return;
        }

        actorDisplayId.append(selectedItem.text);
        actorDisplayId.appendChild(btnDelete);
        actorArray.push(selectedItem);

        var actorIds = "";
        for (var i = 0; i < actorArray.length; i++) {

            if (i == (actorArray.length - 1)) {
                actorIds += (actorArray[i].value);
            }
            else {
                actorIds += (actorArray[i].value + ",");
            }
        }
        document.getElementById("hiddenActors").value = actorIds;
    })

    document.getElementById('deleteAllActors').addEventListener('click', function () {
        actorArray = [];
        ai = 0;
        actorDisplayId.innerHTML = '';
    });
}

// *****Director
var director = [];
function saveSelectedDirector() {
    document.getElementById('loadedDirector').addEventListener('change', function () {
        var selectedValue = this.selectedIndex;
        var itemId = this.value;
        var selectedText = this.options[selectedValue].text;
        var selectedItem = { value: itemId, text: selectedText };
        if (selectedValue < 1) {
            return;
        }
        director = selectedItem;
        var directorId = director.value;

        document.getElementById("hiddenDirector").value = directorId;
    })
}