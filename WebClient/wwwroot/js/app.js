var PingViewModel = function () {
    var self = this;

    self.ping = ko.observableArray([
        { relay: 'a', isTimedOut: false, isReceived: false },
        { relay: 'b', isTimedOut: true, isReceived: false },
        { relay: 'c', isTimedOut: false, isReceived: true } 
    ]);

    self.doPing = function () {
        alert(1);
    };
};

ko.applyBindings(new PingViewModel([]));
 