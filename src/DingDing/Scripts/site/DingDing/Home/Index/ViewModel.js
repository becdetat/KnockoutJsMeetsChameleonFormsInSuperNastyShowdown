namespace('DingDing.Home.Index');

DingDing.Home.Index.ViewModel = function (charactersApiUrl) {
    var self = this;

    self.characters = ko.observableArray();
    self.currentCharacter = ko.observable();
    self.currentCharacterModal = $('#currentCharacterModal');

    self.createNewCharacter = function () {
        toastr.info('Creating a new character');
        self.currentCharacter(new DingDing.Home.Index.Character([], charactersApiUrl));
        self.currentCharacterModal.modal();
    };
    self.startEditingCharacter = function (character) {
        self.currentCharacter(character);
        self.currentCharacterModal.modal();
    };
    self.saveEditedCharacter = function () {
        if (self.currentCharacter().isNew()) {
            self.characters.push(self.currentCharacter());
        }
        self.currentCharacter().save();
        self.currentCharacter(false);
        self.currentCharacterModal.modal('hide');
    };
    self.cancelEditingCharacter = function () {
        self.currentCharacter().cancel();
        self.currentCharacter(false);
        self.currentCharacterModal.modal('hide');
    };
    self.deleteCharacter = function(character) {
        if (confirm("Are you sure you want to delete this character?")) {
            character.delete();
            self.characters.remove(character);
        }
    };

    $.get('/api/characters')
        .error(DingDing.handleAjaxFail)
        .success(function (dtos) {
            self.characters(dtos.map(function (dto) {
                return new DingDing.Home.Index.Character(dto, charactersApiUrl);
            }));
        });
};

DingDing.Home.Index.Character = function (dto, charactersApiUrl) {
    var self = this;

    self.id = ko.observable('');
    self.name = ko.observable('');

    function restoreFrom(newDto) {
        dto = newDto;
        if (!dto) return;
        self.id(dto.Id);
        self.name(dto.Name);
    }
    restoreFrom(dto);

    self.isNew = function () {
        return self.id() === '';
    };

    self.save = function () {
        dto = toDto();
        $.ajax({
            url: '{0}{1}'.formatWith(charactersApiUrl, self.id()),
            data: dto,
            type: self.isNew() ? 'POST' : 'PUT',
            error: DingDing.handleAjaxFail,
            success: function (newDto) {
                restoreFrom(newDto);
            }
        });
    };

    self.cancel = function () {
        restoreFrom(dto);
    };

    self.delete = function () {
        $.ajax({
            url: '{0}{1}'.formatWith(charactersApiUrl, self.id()),
            type: 'DELETE',
            error: DingDing.handleAjaxFail,
            success: function () {
                toastr.info("Hi I'm {0}, and I've just been deleted!".formatWith(self.name()));
            }
        });
    };

    function toDto() {
        return {
            Id: self.id(),
            Name: self.name(),
        };
    }
};