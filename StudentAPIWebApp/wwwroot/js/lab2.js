const uri = 'api/Students';
let students = [];

function Index() {
    fetch(uri)
        .then(response => response.json())
        .then(data => _Index(data))
        .catch(error => console.error('Неможливо отримати список студентів.', error));
}

function Create() {
    const addLastNameTextbox = document.getElementById('add-lastName');
    const addFirstNameTextbox = document.getElementById('add-firstName');
    const addMiddleNameTextbox = document.getElementById('add-middleName');
    const addStudentNumberTextbox = document.getElementById('add-studentNumber');
    const addCourseTextbox = document.getElementById('add-course');
    const addDepartmentIdTextbox = document.getElementById('add-departmentId');
    const addGroupTextbox = document.getElementById('add-group');
    const addSpecialtyTextbox = document.getElementById('add-specialty');

    const student = {
        lastName: addLastNameTextbox.value.trim(),
        firstName: addFirstNameTextbox.value.trim(),
        middleName: addMiddleNameTextbox.value.trim(),
        studentNumber: addStudentNumberTextbox.value,
        course: addCourseTextbox.value,
        departmentId: addDepartmentIdTextbox.value,
        group: addGroupTextbox.value.trim(),
        specialty: addSpecialtyTextbox.value.trim(),
    };
    fetch(uri, {
        method: 'POST',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(student)
    })
        .then(response => response.json())
        .then(() => {
            Index();
            addLastNameTextbox.value = '';
            addFirstNameTextbox.value = '';
            addMiddleNameTextbox.value = '';
            addStudentNumberTextbox.value = '';
            addCourseTextbox.value = '';
            addDepartmentIdTextbox.value = '';
            addGroupTextbox.value = '';
            addSpecialtyTextbox.value = '';
        })
        .catch(error => console.error('Неможливо додати студента', error));
}

function Delete(id) {
    fetch(`${uri}/${id}`, {
        method: 'DELETE'
    })
        .then(() => Index())
        .catch(error => console.error('Неможливо видалити студента', error));
}

function displayEditForm(id) {
    const student = students.find(student => student.id === id);
    document.getElementById('edit-id').value = student.id;
    document.getElementById('edit-lastName').value = student.lastName;
    document.getElementById('edit-firstName').value = student.firstName;
    document.getElementById('edit-middleName').value = student.middleName;
    document.getElementById('edit-studentNumber').value = student.studentNumber;
    document.getElementById('edit-course').value = student.course;
    document.getElementById('edit-departmentId').value = student.departmentId;
    document.getElementById('edit-group').value = student.group;
    document.getElementById('edit-specialty').value = student.specialty;
    document.getElementById('editForm').style.display = 'block';
}

function Edit() {
    const studentId = document.getElementById('edit-id').value;
    const student = {
        id: studentId,
        lastName: document.getElementById('edit-lastName').value.trim(),
        firstName: document.getElementById('edit-firstName').value.trim(),
        middleName: document.getElementById('edit-middleName').value.trim(),
        studentNumber: document.getElementById('edit-studentNumber').value,
        course: document.getElementById('edit-course').value,
        departmentId: document.getElementById('edit-departmentId').value,
        group: document.getElementById('edit-group').value.trim(),
        specialty: document.getElementById('edit-specialty').value.trim(),
    };
    fetch(`${uri}/${studentId}`, {
        method: 'PUT',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(student)
    })
        .then(() => Index())
        .catch(error => console.error('Неможливо оновити дані', error));

    closeInput();

    return false;
}

function closeInput() {
    document.getElementById('editForm').style.display = 'none';
}

function _Index(data) {
    const tBody = document.getElementById('students');
    tBody.innerHTML = '';


    const button = document.createElement('button');

    data.forEach(student => {
        let editButton = button.cloneNode(false);
        editButton.innerText = 'Змінити';
        editButton.setAttribute('onclick', `displayEditForm(${student.id})`);

        let deleteButton = button.cloneNode(false);
        deleteButton.innerText = 'Видалити';
        deleteButton.setAttribute('onclick', `Delete(${student.id})`);

        let tr = tBody.insertRow();


        let td1 = tr.insertCell(0);
        let textNodelastname = document.createTextNode(student.lastName);
        td1.appendChild(textNodelastname);

        let td2 = tr.insertCell(1);
        let textNodefirstname = document.createTextNode(student.firstName);
        td2.appendChild(textNodefirstname);

        let td3 = tr.insertCell(2);
        let textNodemiddlename = document.createTextNode(student.middleName);
        td3.appendChild(textNodemiddlename);

        let td4 = tr.insertCell(3);
        let textNodestudentnumber = document.createTextNode(student.studentNumber);
        td4.appendChild(textNodestudentnumber);

        let td5 = tr.insertCell(4);
        let textNodecourse = document.createTextNode(student.course);
        td5.appendChild(textNodecourse);

        let td6 = tr.insertCell(5);
        let textNodedepartmentid = document.createTextNode(student.departmentId);
        td6.appendChild(textNodedepartmentid);

        let td7 = tr.insertCell(6);
        let textNodegroup = document.createTextNode(student.group);
        td7.appendChild(textNodegroup);

        let td8 = tr.insertCell(7);
        let textNodespecialty = document.createTextNode(student.specialty);
        td8.appendChild(textNodespecialty);

        let td9 = tr.insertCell(8);
        td9.appendChild(editButton);

        let td10 = tr.insertCell(9);
        td10.appendChild(deleteButton);
    });

    students = data;
}



