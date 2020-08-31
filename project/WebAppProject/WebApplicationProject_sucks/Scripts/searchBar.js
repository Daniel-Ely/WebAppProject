
const charactersList = document.getElementById('charactersList');
const searchBar = document.getElementById('searchBar');
var ContentTitleList = document.getElementsByClassName('Title');
var ContentList = document.getElementsByClassName('Content');
var idList = document.getElementsByClassName('ID');
var DateList = document.getElementsByClassName('Date');
var NameList = document.getElementsByClassName('Name');
//
var sContentTitleList = document.getElementsByClassName('Titles');
var sContentList = document.getElementsByClassName('Contents');
var sidList = document.getElementsByClassName('IDs');
var sDateList = document.getElementsByClassName('Dates');
var sNameList = document.getElementsByClassName('Names');

let hpCharacters = [];
let sPost = [];

searchBar.addEventListener('keyup', (e) => {
    const searchString = e.target.value.toLowerCase();

    const filteredCharacters = hpCharacters.filter((character) => {
        return (
            character.Title.toLowerCase().includes(searchString) || character.Content.toLowerCase().includes(searchString)
        );
    });
    if (searchString == "") { displayCharacters(sPost) }
    else displayCharacters(filteredCharacters);
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
        var name = NameList.item(i).attributes.getNamedItem("value");

        hpCharacters.push({
            "Id": id.nodeValue,
            "Title": v.nodeValue,
            "Content": e.nodeValue,
            "Date": date.nodeValue,
            "image": '/src/QutionRoomOwl.png',
            "Name": name.nodeValue
        })
    }
    for (i = 0; i < sContentList.length; i++) {
        var v = sContentTitleList.item(i).attributes.getNamedItem("value");
        var e = sContentList.item(i).attributes.getNamedItem("value");
        var id = sidList.item(i).attributes.getNamedItem("value");
        var date = sDateList.item(i).attributes.getNamedItem("value");
        var name = sNameList.item(i).attributes.getNamedItem("value");

        sPost.push({
            "Id": id.nodeValue,
            "Title": v.nodeValue,
            "Content": e.nodeValue,
            "Date": date.nodeValue,
            "image": '/src/QutionRoomOwl.png',
            "Name": name.nodeValue
        })
    }
    if (document.getElementById("filterd").attributes.getNamedItem("value").nodeValue == "true")
    {
        displayCharacters(hpCharacters);
    }
    else displayCharacters(sPost); 
}
const displayCharacters = (characters) => {
    const htmlString = characters
        .map((character) => {
            if (character.Title == "Question room")
            return `
                            <li class="character">
                               <a href="../QuestionRooms/Details/${character.Id}">
                                  <img src="${character.image}"></img>
                                   <h5>by ${character.Name}  ${character.Date}</h5>
                                    <h2>${character.Title}</h2>
                                     <p>${character.Content}</p>
                                </a>
                            </li>
        `;
            else
                return `
                            <li class="character">
                                <a href="../Posts/Details/${character.Id}">
                                    <img src="${character.image}"></img>  
                                   <h5>by ${character.Name}  ${character.Date}</h5>
                                    <h2>${character.Title}</h2>
                                    <p>${character.Content}</p>
                                </a>
                            </li>
        `;

        })
        .join('');
    charactersList.innerHTML = htmlString;
};

load();
