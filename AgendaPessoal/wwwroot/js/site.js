document.addEventListener("DOMContentLoaded", function () {
    var vm = new PersonViewModel();
    ko.applyBindings(vm);
    vm.load();
});

function PersonViewModel() {
    var self = this;

    self.id = ko.observable(null);
    self.name = ko.observable("");
    self.email = ko.observable("");
    self.birthDate = ko.observable("");
    self.isEditing = ko.observable(false);
    self.people = ko.observableArray([]);

    self.formatDate = function (date) {
        return new Date(date).toLocaleDateString();
    };

    self.save = function () {
        var person = {
            id: self.id(),
            name: self.name(),
            email: self.email(),
            birthDate: self.birthDate()
        };

        var url = self.isEditing() ? '/Person/Update' : '/Person/Create';
        var method = self.isEditing() ? 'PUT' : 'POST';

        $.ajax({
            url: url,
            method: method,
            contentType: 'application/json',
            data: JSON.stringify(person)
        })
            .done(function () {
                self.load();
                self.clear();
            })
            .fail(function (xhr) {
                alert(xhr.responseText);
            });
    };

    self.load = function () {
        $.getJSON('/Person/GetAll', function (data) {
            self.people(data);
        });
    };

    self.delete = function (person) {
        if (!confirm("Deseja excluir essa pessoa?")) return;

        $.ajax({
            url: '/Person/Delete?id=' + person.id,
            method: 'DELETE'
        })
            .done(function () {
                self.load();
            });
    };

    self.edit = function (person) {
        self.id(person.id);
        self.name(person.name);
        self.email(person.email);
        self.birthDate(person.birthDate.split('T')[0]);
        self.isEditing(true);
    };

    self.clear = function () {
        self.id(null);
        self.name("");
        self.email("");
        self.birthDate("");
        self.isEditing(false);
    };
}
