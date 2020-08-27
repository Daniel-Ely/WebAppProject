
const charactersList = document.getElementById('charactersList');
const searchBar = document.getElementById('searchBar');
var ContentTitleList = document.getElementsByClassName('Title');
var ContentList = document.getElementsByClassName('Content');
var filterdRoomList = document.getElementsByClassName('Title');
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
        var v = ContentTitleList.item(i).attributes.getNamedItem("value");
        var e = ContentList.item(i).attributes;
        hpCharacters.push({
            "Title": v.nodeValue,
            "Content": e.nodeValue,
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
                <p>"${character.Content}"</p>
                <img src="${character.image}"></img>
            </li>
        `;
        })
        .join('');
    charactersList.innerHTML = htmlString;
};


load();
