using System.Collections.Generic;
using System.Linq;

public class UICompanentVisitor : ICompanentVisitor {
    private readonly IEnumerable<UICompanent> _companents;

    public UICompanentVisitor(IEnumerable<UICompanent> companents) {
        _companents = companents;
    }

    public UICompanent Companent { get; private set; }

    public void Visit(UICompanentConfig companent) => Visit((dynamic)companent);

    public void Visit(SelectorViewConfig selectorView) => Companent = _companents.FirstOrDefault(companent => companent is SelectorView);
    public void Visit(PolyhedraViewConfig polyhedraView) => Companent = _companents.FirstOrDefault(companent => companent is PolyhedraView);
    public void Visit(PolyhedraWidgetConfig polyhedraWidget) => Companent = _companents.FirstOrDefault(companent => companent is PolyhedraWidget);
}