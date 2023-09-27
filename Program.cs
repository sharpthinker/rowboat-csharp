// See https://aka.ms/new-console-template for more information

IEnumerable<int> GetNeighborStates(int currentState) {
    int[] mutations = {
        // 0b1101,
        // 0b1011,
        // 0b1110,
        0b1001,
        0b1010,
        0b1100,
    };

    for (int i = 0; i < mutations.Length; i++) {
        yield return currentState ^ mutations[i];
    }
}

int GetCount() {
    const int startState = 0;
    const int finalState = 15;

    int[] counts = new int[16];
    bool[] visited = new bool[16];
    Array.Fill(counts, -1);
    Array.Fill(visited, false);
    counts[0] = 1;

    int GetCountInner(int state) {
        if (state == startState) return 1;
        if (counts[state] >= 0) {
            return counts[state];
        }

        int sum = 0;
        IEnumerable<int> neighbors = GetNeighborStates(state);
        
        visited[state] = true;
        foreach(int neighbor in neighbors) {
            if (visited[neighbor]) continue;

            sum += GetCountInner(neighbor);
        }
        counts[state] = sum;
        visited[state] = false;

        return sum;
    }

    return GetCountInner(finalState);
}

Console.WriteLine(GetCount());
