# code to compute the cyclic cyclometry metrics
import pydot
import networkx as nx

def compute_metrics(dot_file):
    # Parse DOT file using pydot
    graphs = pydot.graph_from_dot_file(dot_file)
    if not graphs:
        raise ValueError(f"Could not parse {dot_file}")

    # First graph only
    pydot_graph = graphs[0]

    # Convert to NetworkX DiGraph explicitly
    G = nx.DiGraph()
    for node in pydot_graph.get_nodes():
        if node.get_name() not in ("node", "graph", "edge"):  # ignore attributes
            G.add_node(node.get_name())

    for edge in pydot_graph.get_edges():
        src = edge.get_source()
        dst = edge.get_destination()
        G.add_edge(src, dst)

    # Count nodes and edges
    N = len(G.nodes())
    E = len(G.edges())

    # Cyclomatic Complexity
    CC = E - N + 2

    return N, E, CC


if __name__ == "__main__":
    programs = [
        ("program1.dot", "Program1"),
        ("program2.dot", "Program2"),
        ("program3.dot", "Program3")
    ]

    print(f"{'Program':<30} {'Nodes(N)':<10} {'Edges(E)':<10} {'CC':<10}")
    print("-" * 60)

    for dot_file, name in programs:
        try:
            N, E, CC = compute_metrics(dot_file)
            print(f"{name:<30} {N:<10} {E:<10} {CC:<10}")
        except Exception as e:
            print(f"{name:<30} ERROR: {e}")
