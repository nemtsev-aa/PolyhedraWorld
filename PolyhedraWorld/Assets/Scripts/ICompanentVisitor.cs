public interface ICompanentVisitor {
    void Visit(UICompanentConfig companent);
    void Visit(SelectorViewConfig selectorView);
    void Visit(PolyhedraViewConfig polyhedraView);
    void Visit(ColorVariantViewConfig colortView);
}