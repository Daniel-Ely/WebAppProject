
const charactersList = document.getElementById('charactersList');
const searchBar = document.getElementById('searchBar');
var RoomList = document.getElementsByClassName('Title');
let hpCharacters = [];

searchBar.addEventListener('keyup', (e) => {
    const searchString = e.target.value.toLowerCase();

    const filteredCharacters = hpCharacters.filter((character) => {
        return (
            character.Title.toLowerCase().includes(searchString)
        );
    });
    displayCharacters(filteredCharacters);
});
function load()
{
    //
    //loads the personal Qroom (was filttered by intrest) list
    //
    for (i = 0; i < RoomList.length ; i++)
    {
        var v = RoomList.item(i).attributes.getNamedItem("value");
        hpCharacters.push({
            "Title": v.value,
            "image": '/src/QutionRoomOwl.png'
        })
    }
    displayCharacters(hpCharacters);
   
}

const displayCharacters = (characters) => {
    const htmlString = characters
        .map((character) => {
            return `
            <li class="character">
                <h2>${character.Title}</h2>
                <img src="${character.image}"></img>
            </li>
        `;
        })
        .join('');
    charactersList.innerHTML = htmlString;
};

load();
