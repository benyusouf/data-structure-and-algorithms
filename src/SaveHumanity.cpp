#include <bits/stdc++.h>

using namespace std;

string ltrim(const string &);
string rtrim(const string &);
vector<string> split(const string &);

/*
 * Complete the 'virusIndices' function below.
 *
 * The function accepts following parameters:
 *  1. STRING p
 *  2. STRING v
 */

size_t get_mismatch_count(const char *r, const char *l, size_t s) {
    size_t res(0);
    if (s < 1) {
        return res;
    }
    if (s == 1 && memcmp(r, l, s)) {
        res = 1;
        return res;
    }
    size_t m = s/2;
    const char * r_n = r + m;
    const char * l_n = l + m;
    size_t m_n = s - m;
    bool mismatch_l(false), mismatch_r(false);
    if (memcmp(r, l, m)) {
        mismatch_l = true;
    }
    if (memcmp(r_n, l_n, m_n)) {
        mismatch_r = true;
    }
    if (mismatch_l && mismatch_r) {
        res = 2;
        return res;
    }
    if (mismatch_l) {
        res += get_mismatch_count(r, l, m);
    }
    if ( mismatch_r) {
        res += get_mismatch_count(r_n, l_n, m_n);
    }
    return res;
}

void virusIndices(string p, string v) {
    std::string no_match("No Match!");
    size_t p_s = p.size();
    size_t v_s = v.size();
    bool match_found(false);
    for (size_t i = 0; i < (p_s - v_s + 1); ++i) {
        int mismatch_count(0), match_count(0);
        size_t i_t = i;
        if (!memcmp(p.c_str()+i, v.c_str(), v_s)) {
            match_count = v_s;
        }
        else {
            mismatch_count = get_mismatch_count(p.c_str()+i, v.c_str(), v_s);
            match_count = v_s - mismatch_count;
        }

        if (mismatch_count > 1) {
            continue;
        }
        else {
            cout << i << " ";
            match_found = true;
        }
    }
    if (!match_found) {
        cout << no_match;
    }
    cout << endl;
}

int main()
{
    string t_temp;
    getline(cin, t_temp);

    int t = stoi(ltrim(rtrim(t_temp)));

    for (int t_itr = 0; t_itr < t; t_itr++) {
        string first_multiple_input_temp;
        getline(cin, first_multiple_input_temp);

        vector<string> first_multiple_input = split(rtrim(first_multiple_input_temp));

        string p = first_multiple_input[0];

        string v = first_multiple_input[1];

        virusIndices(p, v);
    }

    return 0;
}

string ltrim(const string &str) {
    string s(str);

    s.erase(
        s.begin(),
        find_if(s.begin(), s.end(), not1(ptr_fun<int, int>(isspace)))
    );

    return s;
}

string rtrim(const string &str) {
    string s(str);

    s.erase(
        find_if(s.rbegin(), s.rend(), not1(ptr_fun<int, int>(isspace))).base(),
        s.end()
    );

    return s;
}

vector<string> split(const string &str) {
    vector<string> tokens;

    string::size_type start = 0;
    string::size_type end = 0;

    while ((end = str.find(" ", start)) != string::npos) {
        tokens.push_back(str.substr(start, end - start));

        start = end + 1;
    }

    tokens.push_back(str.substr(start));

    return tokens;
}
