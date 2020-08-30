
const usersList = document.getElementById('dataTable');
const searchBar = document.getElementById('searchBar');
//user data
var UserName = document.getElementsByClassName('userName');
var Name = document.getElementsByClassName('name');
var Birthday = document.getElementsByClassName('birthday');
var Email = document.getElementsByClassName('email');
var IsProfessinal = document.getElementsByClassName('isP');
var PrifileImage = document.getElementsByClassName('image');
//
let Users = [];

searchBar.addEventListener('keyup', (e) => {
    const searchString = e.target.value.toLowerCase();

    const filteredCharacters = Users.filter((user) => {
        return (
            user.UserName.toLowerCase().includes(searchString) || user.Name.toLowerCase().includes(searchString)
        );
    });
    displayUsers(filteredCharacters);
});
function load() {
    //
    //loads the personal Qroom (was filttered by intrest) list
    //
    for (i = 0; i < UserName.length; i++) {
        var userName = UserName.item(i).attributes.getNamedItem("value").nodeValue;
        var name = Name.item(i).attributes.getNamedItem("value").nodeValue;
        var birthday = Birthday.item(i).attributes.getNamedItem("value").nodeValue;
        var email = Email.item(i).attributes.getNamedItem("value").nodeValue;
        var isP = IsProfessinal.item(i).attributes.getNamedItem("value").nodeValue;
        Users.push({
            "Name": name,
            "UserName": userName,
            "Birthday": birthday,
            "Email": email,
            "image": '/src/QutionRoomOwl.png',
            "IsPro": isP
        })
    }
    displayUsers(Users);
}
const displayUsers = (users) => {
    const htmlString = `<tr>
        <th>profile image</th>
        <th>User Name</th>
        <th>Birthday</th>
        <th>email</th>
    </tr>`
    +
    users
        .map((user) => {
                return `
                            <div class="user">
                               <tr><a href="../Users/Details/${user.UserName}">
                                  <td><img src="${user.image}"></img></td>
                                   <td><h2>${user.UserName}</h2></td>
                                    <td><h2>${user.Birthday}</h2></td>
                                     <td><h2>${user.Email}</h2></td>
                                </a>
                                </tr>
                            </div>
        `;
        })
        .join('');
    dataTable.innerHTML = htmlString;
};

load();
