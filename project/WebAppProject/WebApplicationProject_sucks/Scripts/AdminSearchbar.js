
const usersList = document.getElementById('dataTable');
 const searchBar = document.getElementById('searchBar');

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

      







const load = async () => {
    //user data
    var UserName = document.getElementsByClassName('userName');
    var Name = document.getElementsByClassName('name');
    var Birthday = document.getElementsByClassName('birthday');
    var Email = document.getElementsByClassName('email');
    var IsProfessinal = document.getElementsByClassName('isP');
    var Profession = document.getElementsByClassName('profession');
    var Score = document.getElementsByClassName('score');
    //
   

    //
    //loads the Users (was filttered by paramters by user choice) list
    //
    for (i = 0; i < UserName.length; i++) {
        var userName = UserName.item(i).attributes.getNamedItem("value").nodeValue;
        var name = Name.item(i).attributes.getNamedItem("value").nodeValue;
        var birthday = Birthday.item(i).attributes.getNamedItem("value").nodeValue;
        var email = Email.item(i).attributes.getNamedItem("value").nodeValue;
        var isP = IsProfessinal.item(i).attributes.getNamedItem("value").nodeValue;
        if (isP == "False") {
            Users.push({
                "Name": name,
                "UserName": userName,
                "Birthday": birthday,
                "Email": email,
                "IsPro": isP,
                "Profession":"—",
                "score": "—"
            })
        }
        else {
            var profession = Profession.item(i).attributes.getNamedItem("value").nodeValue;
            var score = Score.item(i).attributes.getNamedItem("value").nodeValue;
            Users.push({
                "Name": name,
                "UserName": userName,
                "Birthday": birthday,
                "Email": email,
                "IsPro": isP,
                "Profession": profession,
                "score": score
            })
        }
        
    }
    displayUsers(Users);
}
const displayUsers = (users) => {
    const htmlString = `<tr>
        <th>User Name</th>
        <th>Name</th>
        <th>Birthday</th>
        <th>Email</th>
        <th>Profession</th>
        <th>Score</th>
    </tr>`
    +
    users
        .map((user) => {
                return `
                            <div class="user">
                               <tr><a href="../Users/Details/${user.UserName}">
                                   <td><h2>${user.UserName}</h2></td>
                                    <td><h2>${user.Name}</h2></td>
                                    <td><h2>${user.Birthday}</h2></td>
                                     <td><h2>${user.Email}</h2></td>
                                    <td><h2>${user.Profession}</h2></td>
                                    <td><h2>${user.score}</h2></td>
                                </a>
                                </tr>
                            </div>
        `;
        })
        .join('');
    usersList.innerHTML = htmlString;
};

