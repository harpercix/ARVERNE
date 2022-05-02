from pathlib import Path
from json import dumps
import re


def jsoner_part(nline, text):
    info_part = {}
    i = nline
    while i < len(text):
        line = text[i]
        if line[:2] == '//':
            i += 1
            continue
        if len(line) == 1 and line == '}':
            return i, info_part
        m = re.match('(?P<key>.+) = (?P<value>.+)$', line)
        if m is None:
            m = re.match('(?P<name>.+)$', line)
            if m is None:
                i += 1
                continue
            i, v = jsoner_part(i+2, text)
            info_part[m['name'].strip()] = v
        else:
            info_part[m['key'].strip()] = m['value']
        i += 1
    return i, info_part


def opener(part_path):
    text = []
    with part_path.open() as file_read:
        for line in file_read:
            text.append(line.strip())
    return jsoner_part(0, text)[1]


def navigate(path):
    paths = []
    for f in path.iterdir():
        if Path.is_file(f):
            if f.name[-4:] == '.cfg':
                paths.append(f)
        if Path.is_dir(f):
            paths.extend(navigate(f))
    return paths


def main():
    p = Path.cwd()
    parts_paths = navigate(p)
    squad_dir = {}
    for part in parts_paths:
        squad_dir[part.name.strip()] = opener(part)
    print(squad_dir)
    with open('test.json', 'w') as file:
        file.write(dumps(squad_dir, indent=2, ensure_ascii=False))

    


main()
