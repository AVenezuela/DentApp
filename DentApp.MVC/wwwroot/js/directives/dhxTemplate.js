function templateDirective($filter) {
  /*
  scheduler.aFilter = $filter;

  return {
    restrict: 'AE',
    terminal: true,

    link: function ($scope, $element, $attrs, $controller) {
      $element[0].style.display = 'none';
      
      var template = $element[0].innerHTML;
      template = template.replace(/[\r\n]/g, "").replace(/"/g, "\\\"").replace(/\{\{event\.([^\}]+)\}\}/g, function (match, prop) {
        if (prop.indexOf("|") != -1) {
          var parts = prop.split("|");
          return "\"+scheduler.aFilter('" + (parts[1]).trim() + "')(event." + (parts[0]).trim() + ")+\"";
        }
        return '"+event.' + prop + '+"';
      });
      var templateFunc = Function('sd', 'ed', 'event', 'return "' + template + '"');

      scheduler.templates[$attrs.dhxTemplate] = templateFunc;
    }
  };
  */
}