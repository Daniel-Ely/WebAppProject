
const charactersList = document.getElementById('charactersList');
const searchBar = document.getElementById('searchBar');
var ContentTitleList = document.getElementsByClassName('Title');
var ContentList = document.getElementsByClassName('Content');
var idList = document.getElementsByClassName('ID');
var DateList = document.getElementsByClassName('Date');

let hpCharacters = [];

searchBar.addEventListener('keyup', (e) => {
    const searchString = e.target.value.toLowerCase();

    const filteredCharacters = hpCharacters.filter((character) => {
        return (
            character.Title.toLowerCase().includes(searchString) || character.Content.toLowerCase().includes(searchString)
        );
    });
    displayCharacters(filteredCharacters);
});
function load()
{
    //
    //loads the personal Qroom (was filttered by intrest) list
    //
    for (i = 0; i < ContentList.length ; i++)
    {
        var v = ContentTitleList.item(i).attributes.getNamedItem("value");
        var e = ContentList.item(i).attributes.getNamedItem("value");
        var id = idList.item(i).attributes.getNamedItem("value");
        var date = DateList.item(i).attributes.getNamedItem("value");

        hpCharacters.push({
            "Id": id.nodeValue,
            "Title": v.nodeValue,
            "Content": e.nodeValue,
            "Date": date,
            "image": '/src/QutionRoomOwl.png'
        })
    }
    displayCharacters(hpCharacters);
   
}


const displayCharacters = (characters) => {
    const htmlString = characters
        .map((character) => {
            if (character.Title == "Question")
            return `
                            <li class="character">
                               <a href="../Posts/Details/" + ${character.Id}>
                                <a href=@linkToQR>
                                   <img src="${character.image}"></img>
                                    <h2>${character.Title}</h2>
                                     <p>${character.Content}</p>
                                    <h5>publish date ,  ${character.Date.Month}.${character.Date.Day}.${character.Date.Year}</h5>
                                </a>
                            </li>
        `;
            else
                return `
                            <li class="character">
                                <a href="../Posts/Details/" + ${character.Id}>
                                   <img src="${character.image}"></img>
                                    <h2>${character.Title}</h2>
                                    <p>${character.Content}</p>
                                    <h5>publish date ,  ${character.Date.Month}.${character.Date.Day}.${character.Date.Year}</h5>
                                </a>
                            </li>
        `;

        })
        .join('');
    charactersList.innerHTML = htmlString;
};


load();
